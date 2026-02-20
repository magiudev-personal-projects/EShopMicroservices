using DiscountGrpc.Data;
using DiscountGrpc.Maps;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace DiscountGrpc.Services;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(
        GetDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(coupon =>
            coupon.ProductName == request.ProductName
        );
        if (coupon == null)
            throw new RpcException(
                new Status(StatusCode.NotFound, $"Coupon {coupon?.ProductName} not found")
            );

        logger.LogInformation(
            "Discount is retrieved for ProductName : {productName}, Amount : {amount}",
            coupon.ProductName,
            coupon.Amount
        );

        return coupon.ToGrpcModel();
    }

    public override Task<CouponModel> CreateDiscount(
        InsertCouponRequest request,
        ServerCallContext context
    )
    {
        return base.CreateDiscount(request, context);
    }

    public override Task<CouponModel> UpdateDiscount(
        InsertCouponRequest request,
        ServerCallContext context
    )
    {
        return base.UpdateDiscount(request, context);
    }

    public override Task<DeleteDiscountResponse> DeleteDiscount(
        DeleteDiscountRequest request,
        ServerCallContext context
    )
    {
        return base.DeleteDiscount(request, context);
    }
}
