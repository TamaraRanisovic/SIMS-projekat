using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class CouponService
    {
        CouponRepository couponRepository = new CouponRepository();

        public CouponService()
        {
            
        }

        public List<Coupon> GetAll()
        {
            return couponRepository.GetAll();
        }

        public Coupon GetById(int id)
        {
            return couponRepository.GetById(id);
        }

    }
}
