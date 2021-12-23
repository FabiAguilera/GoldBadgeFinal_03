using KomodoClaims.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims.Repository
{
    public class ClaimsRepo
    {
        private static readonly Queue<Claims> claimList = new Queue<Claims>();

        private int _count = 0;

        public bool CreateClaim(Claims claims)
        {
            _count++;
            claims.ClaimId = _count++;
            claimList.Enqueue(claims);
            return true;
        }

        public Claims GetClaimInfo()
        {
            //get list of claims.
            var claims = claimList;

            // make it so list shows 1 item
            Claims claim = claims.Peek();

            //return the item
            return claim;
        }


        public List<Claims> ViewAllClaims()
        {
          return claimList.ToList();
        }

        public bool RemoveClaim()
        {
            _count--;
            claimList.Dequeue();
            return true;
        }
    }
}
