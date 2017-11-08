using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testKunder.capaObjeto;

namespace testKunder.Controllers
{
    public class timeController : ApiController
    {
        /// <summary> Método que verifica si una cadena es numérica o si contiene valores numéricos.
        /// <param name="value">String con hora en formato militar (23hrs.).</param>
        /// <returns>String con la hora actual en formato UTC​ ​ISO​ ​8601​.</returns>
        [HttpGet()]
        public HttpResponseMessage time(string value)
        {
            if(value is null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cadena vacía."); ;
            }else if(value == "")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cadena vacía."); ;
            }
            else
            {
                if(value.LongCount() != 5)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Formato de hora errada."); ;
                }
                else
                {
                    try
                    {
                        String[] substrings = value.Split(':');
                        int _hora = Convert.ToInt16(substrings[0]);
                        int _minutos = Convert.ToInt16(substrings[1]);
                        bool _esHoraCorrecta = verificarHoraMilitar(_hora, true);
                        bool _sonMinutosCorrectos = verificarHoraMilitar(_minutos, true);

                        if(_esHoraCorrecta && _sonMinutosCorrectos)
                        {
                            DateTime _hoy = DateTime.Today;

                            cadena _cadena = new cadena();
                            _cadena.data = _hoy.ToString("yyyy-MM-ddTHH:mm:ssZ");
                            return Request.CreateResponse(HttpStatusCode.OK, _cadena); ;
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, "Formato de hora errada."); ;
                        }                        
                    }
                    catch (FormatException)
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Formato de fecha errada."); ;
                    }
                }
            }
        }


        /// <summary> Método que verifica si los valores numéricos cumplen con la hora militar (horas y minutos).
        /// <param name="valor">Int con el valor correspondiente a hora/minuto.</param>
        /// <param name="esHora">Valor lógico que indica si la variable "valor" es Hora o Minuto, tomando los siguientes valores: true para hora, false para minuto.</param>
        /// <returns>Falso si no cumple con el formato militar, true si lo cumple</returns>
        private Boolean verificarHoraMilitar(int valor, bool esHora)
        {
            if (esHora) //Verificamos que la hora vaya del 0 al 23 según la hora militar
            {
                if (valor >= 0 && valor <= 23)
                {
                    return true;
                }
            }
            else //Verificamos que los minutos vayan del 0 al 59
            {
                if (valor >= 0 && valor <= 59)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
