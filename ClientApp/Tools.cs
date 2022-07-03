using System.Text.Json;
using RestSharp;

namespace ClientApp;

public  class Tools
{
    private readonly RestClient _client;

    public Tools()
    {
        _client = new RestClient("https://localhost:7104/");
    }
    public RestResponse CreateOrder(object order)
    {
        var args = JsonSerializer.Serialize(order);
        var request = new RestRequest("api/Orders", Method.Post);
        request.AddHeader("content-type", "application/json");
        request.AddParameter("application/json", args, ParameterType.RequestBody);

        return _client.Execute(request);
    }

    public string CreateUser(object user)
    {
        var request = new RestRequest("api/Users", Method.Post);
        request.AddHeader("content-type", "application/json");
        request.AddParameter("application/json", JsonSerializer.Serialize(user), ParameterType.RequestBody);
        var response = _client.Execute(request);
        return response.Content;
    }

    public List<OrderDto> GetOrders(string userId)
    {
        var path = string.IsNullOrEmpty(userId) ? string.Empty : $"/{userId}";
        var request = new RestRequest($"api/Orders{path}", Method.Get);
        request.AddHeader("content-type", "application/json");
        var response = _client.Execute(request);
        return JsonSerializer.Deserialize<List<OrderDto>>(response.Content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}