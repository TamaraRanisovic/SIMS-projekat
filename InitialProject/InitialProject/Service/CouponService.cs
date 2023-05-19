using InitialProject.Interfaces;
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
        private readonly ICouponRepository CouponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            CouponRepository = couponRepository;
        }
        public void Delete(Coupon coupon)
        {
            CouponRepository.Delete(coupon);
        }

        public List<Coupon> GetAll()
        {
            return CouponRepository.GetAll();
        }

        public Coupon GetById(int id)
        {
            return CouponRepository.GetById(id);
        }

        public void UseCoupon(int couponId)
        {
            CouponRepository.UseCoupon(couponId);
        }
        public void RemoveExpiredCoupons()
        {
            CouponRepository.RemoveExpiredCoupons();
        }

    }
}
