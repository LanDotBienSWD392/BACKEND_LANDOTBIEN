using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Tools
{
    public class BidHub : Hub
    {
        public async Task SendBidUpdate(object bid)
        {
            // Gửi thông điệp bid mới tới tất cả các máy khách đã kết nối
            await Clients.All.SendAsync("NewBid", bid);
        }

        public override async Task OnConnectedAsync()
        {
            // Xử lý logic khi một máy khách kết nối vào Hub
            // Ví dụ: gửi danh sách bid mới nhất tới máy khách
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Xử lý logic khi một máy khách ngắt kết nối từ Hub
            await base.OnDisconnectedAsync(exception);
        }
    }
}
