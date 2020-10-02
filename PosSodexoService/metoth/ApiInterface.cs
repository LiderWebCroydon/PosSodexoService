using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;
using System.Net;

namespace PosSodexoService.metoth
{
    public class ApiInterface
    {

        /// <summary>
        /// Genera la peticion para retornar un token de sesion vigente y valido
        /// </summary>
        /// <param name="tokenRequest">Objeto para generar JSON</param>
        /// <returns></returns>
        public string getToken(TokenRequest tokenRequest)
        {
            string requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(tokenRequest);
            IRestResponse restResponse1 = apiSodexo("ValidateSesionStore", requestJson, "");
            HttpStatusCode statusCode = restResponse1.StatusCode;
            if ((int)statusCode == 200){

                TokenResponse tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(restResponse1.Content);
                return tokenResponse.token;
            }
            else{
                return restResponse1.Headers.ToList()
                    .Find(x => x.Name == "Token")
                    .Value.ToString();
            }            
        }

        /// <summary>
        /// Arma la solicitud para la validacion de un bono
        /// </summary>
        /// <param name="bonusRequest">Objeto para generar JSON</param>
        /// <param name="token">Token de sesion valido para la peticion</param>
        /// <returns></returns>
        public BonusResponse validaeBonus(BonusRequest bonusRequest, string token)
        {
            string requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(bonusRequest);
            BonusResponse bonusResponse = new BonusResponse();
            IRestResponse restResponse = apiSodexo("ValidateBonus", requestJson, token);
            HttpStatusCode statusCode = restResponse.StatusCode;
            switch ((int)statusCode)
            {
                case 404:
                    bonusResponse.descripcion = "Código de bono no existe";
                    bonusResponse.codigo = "404";
                    break;
                default:
                    bonusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BonusResponse>(restResponse.Content);
                    break;
            }
            return bonusResponse;
        }

        /// <summary>
        /// Arma la solicitud para la anulacion de un bono
        /// </summary>
        /// <param name="bonusRequest">Objeto para generar JSON</param>
        /// <param name="token">Token de sesion valido para la peticion</param>
        /// <returns></returns>
        public BonusResponse removeBonus(BonusRequest bonusRequest, string token)
        {
            string requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(bonusRequest);
            BonusResponse bonusResponse = new BonusResponse();
            IRestResponse restResponse = apiSodexo("RemoveBonus", requestJson, token);
            bonusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<BonusResponse>(restResponse.Content);
            return bonusResponse;
        }

        /// <summary>
        /// Procesa requrimientos hacia el API SODEXO
        /// </summary>
        /// <param name="urlRequest">Complemento url del metodo a invocar</param>
        /// <param name="jsonRequest">Json a enviar dentro de body en el request HTTPS</param>
        /// <param name="token">Token de sesion valido para la peticion</param>
        /// <returns></returns>
        public IRestResponse apiSodexo(string urlRequest, string jsonRequest, string token)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://www.sodexoservicios.com.co/ReembolsoEnLineaWS/" + urlRequest);
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            if(jsonRequest != "ValidateSesionStore")
                request.AddHeader("Authorization", "Bearer " + token);
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            IRestResponse restResponse = client.Execute(request);
            return restResponse;
        }

        /// <summary>
        /// Genera clase para request de ValidateSesion
        /// </summary>
        /// <param name="cuc">Codigo Unico de Comercio</param>
        /// <returns></returns>
        public TokenRequest getObjectToken(string cuc)
        {
            TokenRequest tokenRequest = new TokenRequest();
            tokenRequest.contrasenia = "Tarjeta11";
            tokenRequest.cuc = cuc;
            tokenRequest.usuario = "Croydon";
            return tokenRequest;
        }
    }
}