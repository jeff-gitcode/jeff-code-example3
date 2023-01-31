using RestSharp;
using MediatR;
using System.Threading.Tasks;
namespace Rest;

public interface IRestService
{
    Task<TResponse> Post<TRequest,TResponse>(string endpoint, TRequest request)
        where TRequest: class
        where TResponse: new();
}

public class RestService: IRestService
{
    private readonly RestClient _client;
    private readonly string _url = "http://localhost:5195";

    public RestService()
    {
        this._client = new RestClient(this._url);
    }

    public async Task<TResponse> Post<TRequest, TResponse>(string endpoint, TRequest request)
        where TRequest: class
        where TResponse: new()
    {
        var restRequest = new RestRequest(endpoint);
        
        restRequest.AddHeader("Content-type", "application/json");

        restRequest.AddJsonBody<TRequest>(request);
 
        return await this._client.PostAsync<TResponse>(restRequest);
    }
}