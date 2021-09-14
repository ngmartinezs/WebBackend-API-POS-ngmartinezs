using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBackendAPIPOSngmartinezs
{
    public class Util
    {
        public static int COD_CREATED_OK = 202;
        public static int COD_UPDATED_OK = 204;
        public static int COD_FINDED_OK = 200;
        public static int COD_DELETED_OK = 205;

        public static int COD_ERROR_INTERNO = 500;
        public static int COD_ERROR_BADRQUEST = 400;
        public static int COD_ERROR_NOTFOUND = 404;

        public static string MSG_CREATED_OK = "Registro Creado";
        public static string MSG_UPDATED_OK = "Registro Actualizado";
        public static string MSG_FINDED_OK  = "Informacion Encontrada";
        public static string MSG_DELETED_OK = "Registro Retirado";

        public static string ERROR_BADREQUEST = "Parametros Invalidos/Mal Request";
        public static string ERROR_SERVICIO = "Error Durante La Ejecucion";


        public static string generateRandom() {

            return new Random().Next(11111, 999999).ToString();
        }
    }
}
