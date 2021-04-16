using System.Reactive;
using EvolutionOfTrust;
using ReactiveUI;

namespace EvolutionUI.ViewModels
{
    public class PointSystemViewModel : ViewModelBase
    {
        string coopPoints;
        string cheatPoints;
        string cheatedPoints;
        string cheatBothPoints;

        public string CoopPoints
        {
            get => coopPoints;
            set => this.RaiseAndSetIfChanged(ref coopPoints, value);
        }
        public string CheatPoints
        {
            get => cheatPoints;
            set => this.RaiseAndSetIfChanged(ref cheatPoints, value);
        }
        public string CheatedPoints
        {
            get => cheatedPoints;
            set => this.RaiseAndSetIfChanged(ref cheatedPoints, value);
        }
        public string CheatBothPoints
        {
            get => cheatBothPoints;
            set => this.RaiseAndSetIfChanged(ref cheatBothPoints, value);
        }

        public PointSystemViewModel()
        {
            var proceedActive = this.WhenAnyValue(
                a => a.CoopPoints,
                b => b.CheatPoints,
                c => c.CheatedPoints,
                d => d.CheatBothPoints,
                (a, b, c, d) => !string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b) && !string.IsNullOrWhiteSpace(c) && !string.IsNullOrWhiteSpace(d)
            );
            Proceed = ReactiveCommand.Create(
                () => new PointsSystem
                {
                    CoopPoints = int.Parse(CoopPoints),
                    CheatPoints = int.Parse(CheatPoints),
                    CheatedPoints = int.Parse(CheatedPoints),
                    CheatBothPoints = int.Parse(CheatBothPoints)
                },
                proceedActive);
        }

        public ReactiveCommand<Unit, PointsSystem> Proceed { get; }

    }
}
