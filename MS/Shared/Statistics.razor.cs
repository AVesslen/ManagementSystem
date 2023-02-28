using MS.Services;
using MS.Shared.Entities;
using MS.Shared;
using Microsoft.AspNetCore.Components;

namespace MS.Shared
{
    public partial class Statistics
    {
        private IEnumerable<Machine> machines = new List<Machine>();
        public int MachineCounter { get; set; } = 0;
        public int OnlineCounter { get; set; } = 0;
        [Inject]
        public IMSClient MSClient { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            machines = await MSClient.GetAllAsync();
            MachineCounter = machines.Count();
            OnlineCounter = machines.Where(m => m.IsOnline == true).Count();
        }
    }
}
