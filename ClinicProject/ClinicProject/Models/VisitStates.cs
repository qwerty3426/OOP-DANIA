using ClinicProject.Models;
using System;

namespace ClinicProject.Models
{
    public interface IVisitState
    {
        string StateName { get; }
        void Start(Visit visit);
        void Complete(Visit visit);
        void Cancel(Visit visit);
    }

    public class ScheduledState : IVisitState
    {
        public string StateName => "Scheduled";

        public void Start(Visit visit) => visit.TransitionTo(new InProgressState());

        public void Complete(Visit visit) =>
            throw new InvalidOperationException("Неможливо завершити візит, який ще не розпочався.");

        public void Cancel(Visit visit) => visit.TransitionTo(new CanceledState());
    }

    public class InProgressState : IVisitState
    {
        public string StateName => "InProgress";

        public void Start(Visit visit) =>
            throw new InvalidOperationException("Візит вже знаходиться в процесі.");

        public void Complete(Visit visit) => visit.TransitionTo(new CompletedState());

        public void Cancel(Visit visit) => visit.TransitionTo(new CanceledState());
    }

    public class CompletedState : IVisitState
    {
        public string StateName => "Completed";

        public void Start(Visit visit) =>
            throw new InvalidOperationException("Цей візит вже успішно завершено.");

        public void Complete(Visit visit) =>
            throw new InvalidOperationException("Візит вже завершено раніше.");

        public void Cancel(Visit visit) =>
            throw new InvalidOperationException("Неможливо скасувати вже завершений візит.");
    }

    public class CanceledState : IVisitState
    {
        public string StateName => "Canceled";

        public void Start(Visit visit) =>
            throw new InvalidOperationException("Неможливо розпочати скасований візит.");

        public void Complete(Visit visit) =>
            throw new InvalidOperationException("Неможливо завершити скасований візит.");

        public void Cancel(Visit visit) =>
            throw new InvalidOperationException("Візит вже було скасовано.");
    }
}