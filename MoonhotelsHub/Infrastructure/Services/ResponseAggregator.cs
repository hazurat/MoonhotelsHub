using MoonhotelsHub.Application.Services;
using MoonhotelsHub.Domain.Model;

namespace MoonhotelsHub.Infrastructure.Services
{
    //Ahora mismo sólo mete las tarifas dentro de cada habitación sin pensar.
    //Implementando la interfaz en otra clase podrían añadirse otras formas de agregación.
    public class ResponseAggregator : IResponseAggregator
    {
        public HubResponse Aggregate(HubResponse hubResponse, List<HubResponse> apiResponses)
        {
            foreach (var apiResponse in apiResponses)
            {
                foreach (Room room in apiResponse.Rooms)
                {
                    var existingRoom = hubResponse.Rooms.FirstOrDefault(r => r.RoomId == room.RoomId);

                    // Una habitación nueva.
                    if (existingRoom == null)
                        hubResponse.Rooms.Add(room);
                    // La habitación existe, añadimos las tarifas del proveedor.
                    else
                        existingRoom.Rates.AddRange(room.Rates);
                }
            }
            return hubResponse;
        }




    }
}
