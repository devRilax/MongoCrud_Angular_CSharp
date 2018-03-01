using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.ExceptionHelper
{
    public class ExceptionHandler
    {
        public void handleException(Exception ex)
        {
            if (ex is BLLException)
            {
                throw new BLLException(ex.Message);
            }

            if (ex is DataBaseException)
            {
                throw new BLLException("Unknown error, contact the administrator");
            }
        }
    }
}
