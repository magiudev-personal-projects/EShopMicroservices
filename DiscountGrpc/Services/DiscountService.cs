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

    public override async Task<CouponModel> CreateDiscount(
        InsertCouponRequest request,
        ServerCallContext context
    )
    {
        var coupon = request.Coupon.ToModel();
        if (coupon is null)
            throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid request object.")
            );

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount is successfully created. ProductName : {ProductName}",
            coupon.ProductName
        );

        var couponModel = coupon.ToGrpcModel();
        return couponModel;
    }

    public override async Task<CouponModel> UpdateDiscount(
        InsertCouponRequest request,
        ServerCallContext context
    )
    {
        if (request.Coupon == null)
        {
            throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid request object.")
            );
        }

        var id = request.Coupon?.Id;
        var coupon = dbContext.Coupons.Any(coupon => coupon.Id == id);

        if (!coupon)
            throw new RpcException(
                new Status(StatusCode.NotFound, $"Coupon with id: {id} not found")
            );

        var newCoupon = request.Coupon!.ToModel();

        dbContext.Coupons.Update(newCoupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount is successfully updated. ProductName : {ProductName}",
            newCoupon.ProductName
        );

        var couponModel = newCoupon.ToGrpcModel();
        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(
        DeleteDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x =>
            x.ProductName == request.ProductName
        );

        if (coupon is null)
            throw new RpcException(
                new Status(
                    StatusCode.NotFound,
                    $"Discount with ProductName={request.ProductName} is not found."
                )
            );

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount is successfully deleted. ProductName : {ProductName}",
            request.ProductName
        );

        return new DeleteDiscountResponse { IsSuccess = true };
    }
}
