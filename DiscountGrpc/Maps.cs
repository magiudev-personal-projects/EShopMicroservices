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

    public static Coupon? ToModel(this CouponModel couponModel)
    {
        try
        {
            return new Coupon
            {
                ProductName = couponModel.ProductName,
                Description = couponModel.Description,
                Amount = couponModel.Amount,
            };
        }
        catch
        {
            return null;
        }
    }
}
