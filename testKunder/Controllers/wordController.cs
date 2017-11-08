using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testKunder.capaObjeto;

namespace testKunder.Controllers
{
    public class wordController : ApiController
    {
        /// <summary> Método que recibe una palabra de 4 caracteres y retorna su valor en mayúsculas.
        /// <param name="cadena">String de 4 caracteres (no numéricos).</param>
        /// <returns>String ingresado al inicio en mayúsculas.</returns>
        [HttpPost()]
        public HttpResponseMessage word(cadena cadena)
        {
            if (cadena is null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Objeto vacío.");
            }
            else if (cadena.data == "")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cadena vacía.");
            }
            else
            {
                Boolean _esNumero = esNumero(cadena.data);
                Boolean _tieneNumeros = tieneNumeros(cadena.data);

                if (_esNumero)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Cadena con valores númericos.");
                else if (_tieneNumeros)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Cadena con valores númericos.");
                else
                {
                    if (cadena.data.LongCount() != 4)
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Cadena mayor a  4 caracteres.");
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, cadena.data.ToUpper());
                    }
                }
            }
        }

        /// <summary> Método que verifica si una cadena es numérica.
        /// <param name="numString">String a verificar.</param>
        /// <returns>Falso si no contiene números, true si es numérico.</returns>
        private Boolean esNumero(string numString)
        {
            int number1 = 0;
            bool bandera = int.TryParse(numString, out number1);
            return bandera;
        }

        /// <summary> Método que verifica si una cadena contiene valores numéricos.
        /// <param name="numString">String a verificar.</param>
        /// <returns>Falso si no contiene números, true si hay valores numéricos.</returns>
        private Boolean tieneNumeros(string numString)
        {
            bool bandera = false;

            for (int i = 0; i <= 9; i++)
            {
                if (numString.Contains(Convert.ToString(i)))
                {
                    bandera = true;
                }

            }

            return bandera;
        }
    }
}
