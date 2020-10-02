using PosSodexoService.metoth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PosSodexoService
{
    /// <summary>
    /// Servicio de conexion a API REST de sodexo para el sistema POS Croydon
    /// Croydon 2020.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ConexionService : WebService
    {
        /// <summary>
        /// Metodo para la validacion del bono
        /// </summary>
        /// <param name="bonusRequest">Objeto de parametro</param>
        /// <returns></returns>
        [WebMethod]
        public BonusResponse ValidateBonus(BonusRequest bonusRequest)
        {
            ApiInterface apiInterface = new ApiInterface();
            return apiInterface.validaeBonus(bonusRequest, apiInterface.getToken(apiInterface.getObjectToken(bonusRequest.cuc)));
        }


        /// <summary>
        /// Metodo para la anulacion del bono
        /// </summary>
        /// <param name="bonusRequest">Objeto de parametro</param>
        /// <returns></returns>
        [WebMethod]
        public BonusResponse RemoveBonus(BonusRequest bonusRequest)
        {
            ApiInterface apiInterface = new ApiInterface();
            return apiInterface.removeBonus(bonusRequest, apiInterface.getToken(apiInterface.getObjectToken(bonusRequest.cuc)));
        }
    }
}
