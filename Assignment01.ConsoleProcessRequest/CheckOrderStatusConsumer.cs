using Assignment01.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01.ConsoleProcessRequest
{
    public class CheckOrderStatusConsumer :
    IConsumer<CheckOrderStatus>
    {
        public CheckOrderStatusConsumer()
        {
        }

        public async Task Consume(ConsumeContext<CheckOrderStatus> context)
        {
            int orderId = Convert.ToInt32(context.Message.OrderId);
            if (orderId % 2 == 0)
            {
                await context.RespondAsync<OrderStatusResult>(new OrderStatusResult
                {
                    StatusText = "Failed",
                });
            }
            else
            {
                await context.RespondAsync<OrderStatusResult>(new OrderStatusResult
                {
                    StatusText = "OK",
                });
            }
        }
    }
}
