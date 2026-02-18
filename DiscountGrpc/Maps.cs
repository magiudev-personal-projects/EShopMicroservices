using DiscountGrpc.Models;

namespace DiscountGrpc.Maps;

public static class Maps
{
    public static CouponModel ToGrpcModel(this Coupon coupon)
    {
        return new CouponModel
        {
            Id = coupon.Id,
            ProductName = coupon.ProductName,
            Description = coupon.Description,
            Amount = (int)coupon.Amount,
        };
    }
}
