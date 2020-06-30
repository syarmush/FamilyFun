using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFun.Web.Models
{
    public class ColorRetriever
    {
        public IEnumerable<string> RetieveColors()
        {

            ////flamboyant colors
            //$drunkTankPink: #ff91af; 
            //$bastardAmber: #fda08f;
            //$poodleSkirt: #FFAEBB;
            //$lemonMeringue: #F6EABE;
            //$acidWatchBlue: #3967cb;
            //$succulentGreen: #2bd567;
            //$purpleRain: #ca7cd8;
            //$tronTurqouise: #10e6e2;
            //$miamiPink: #ff68a8;
            //$pacmanYellow: #f9eb0f;
            //$powersuitRed: #ff2152;
            //$promSuitBlue: #00a2d3;
            //$lavaLampGlo: #fd4d2e;
            //$haveANiceDayYellow: #f8ca38;
            //$roadtripBlue: #4ac6d7;
            //$motelSunset: #f5855b;
            //$sodaFountainBlue: #68bab7;
            //$marilynInputCrimsonRed: #e81b22;
            return new string[] {"#ff91af","#fda08f","#FFAEBB","#F6EABE","#3967cb","#2bd567","#ca7cd8","#10e6e2",
                "#ff68a8","#f9eb0f","#ff2152","#00a2d3","#fd4d2e","#f8ca38","#4ac6d7","#f5855b","#68bab7","#e81b22" };

        }
    }
}
