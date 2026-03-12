using System;

namespace ClinicProject.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int DoctorId { get; set; }
        public User? Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; } = string.Empty;

        public string StatusDb { get; set; } = "Scheduled";

        private IVisitState _state;

        public Visit()
        {
            _state = new ScheduledState(); 
        }

        public void InitializeState()
        {
            _state = StatusDb switch
            {
                "Scheduled" => new ScheduledState(),
                "InProgress" => new InProgressState(),
                "Completed" => new CompletedState(),
                "Canceled" => new CanceledState(),
                _ => new ScheduledState()
            };
        }

        public void TransitionTo(IVisitState state)
        {
            _state = state;
            StatusDb = state.StateName; 
        }

        public string CurrentStatus => _state.StateName;

        public void Start() => _state.Start(this);
        public void Complete() => _state.Complete(this);
        public void Cancel() => _state.Cancel(this);
    }
}