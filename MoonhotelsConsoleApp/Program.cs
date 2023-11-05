using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoonhotelsHub;
using MoonhotelsHub.Application;
using MoonhotelsHub.Application.Apis;
using MoonhotelsHub.Application.Apis.HotelLegs;
using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Infrastructure.Apis.HotelLegs;

namespace MoonhotelsConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al Buscador de Habitaciones de MoonHotels");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine(Environment.NewLine);
            Thread.Sleep(1000);

            // Inyectando dependencias
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddMoonHotelsHub();
            builder.Services.AddTransient<IHotelLegsApi, HotelLegsApiStub>();

            //Jugando con las dependencias para cambiar el numero de proveedores (inútil, pero divertido x'D)
            Console.WriteLine("Elije un numero de proveedores de habitaciones (1-3):");
            var key = Console.ReadKey();
            int proveedores = key.KeyChar switch
            {
                '1' => 1,
                '2' => 2,
                '3' => 3,
                _ => 0
            };
            if (proveedores == 0)
            {
                Console.WriteLine("Solo proveedores entre 1 y 3 porfa.");
                return;
            }
            for (int i = 1; i<proveedores; i++)
            {
                builder.Services.AddTransient<IHotelsProviderConnector, HotelLegsConnector>();
            }

            //Generamos los servicios
            IHost host = builder.Build();
            //Y nos traemos el Hub ya inyectado
            var bookingEngineConnector = host.Services.GetService<IBookingEngineConnector>();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("A continuación lanzaremos una peticiones al servicio");
            Thread.Sleep(2000);

            var request = @"{""hotelId"":1,""checkIn"":""2018-10-20"",""checkOut"":""2018-10-25"",""numberOfGuests"":3,""numberOfRooms"":2,""currency"":""EUR""}";
            Console.WriteLine("Petición: ");
            Thread.Sleep(1000);
            Console.WriteLine(request);
            Console.WriteLine(Environment.NewLine);
            Thread.Sleep(2000);
            Console.WriteLine("Respuesta: ");
            var res = bookingEngineConnector!.Search(request);
            Console.Write(res);

            Console.ReadKey();
            Console.WriteLine("Adios");
        }

        internal class HotelLegsApiStub : IHotelLegsApi
        {
            public string Search(string request)
            {
                return @"{""results"":[{""room"":1,""meal"":1,""canCancel"":false,""price"":123.48},{""room"":1,""meal"":1,""canCancel"":true,""price"":150},{""room"":2,""meal"":1,""canCancel"":false,""price"":148.25},{""room"":2,""meal"":2,""canCancel"":false,""price"":165.38}]}";
            }
        }




    }
}