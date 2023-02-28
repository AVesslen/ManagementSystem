using MS.Shared;
using MS.Services;
using MS.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace MS.Pages
{
    public partial class MachineOverview
    {

        public List<Machine> machines = new List<Machine>();
        protected string StatusClass = string.Empty;
        protected string Message = string.Empty;

        [Inject]
        public IMSClient MSClient { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var res = await MSClient.GetAllAsync();
            if (res != null) machines = res.ToList();
        }



        private async Task Delete(Machine machine)
        {
            if (machine is null)
            {
                throw new ArgumentNullException(nameof(machine));
            }

            var isRemoved = await MSClient.RemoveAsync(machine.Id);

            if (isRemoved)
            {
                machines.Remove(machine);
                StatusClass = "alert-success";
                Message = "Your device was successfully removed.";
            }
        }

        private async Task StatusToggle(Machine machine)
        {
            if (machine is null)
            {
                throw new ArgumentNullException(nameof(machine));
            }

            machine.IsOnline = (machine.IsOnline == true) ? false : true;

            machine.LastUpdated = DateTime.Now;
            var isEdited = await MSClient.PutAsync(machine);

            if (isEdited)
            {
                StatusClass = "alert-success";
                Message = $"Your device status is updated.";
            }
        }
    }
}
