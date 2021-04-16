using EvolutionOfTrust;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;

namespace EvolutionUI.ViewModels
{
    class PrepareTournamentViewModel : ViewModelBase
    {
        PointsSystem pointsSystem;
        string roundAmount;
        string tournamentAmount;
        string eliminateReproduceAmount;
        string mistakeChance;
        MainWindowViewModel windowVM;

        public PointsSystem PointsSystem
        {
            get => pointsSystem;
            private set => this.RaiseAndSetIfChanged(ref pointsSystem, value);
        }
        public string RoundAmount
        {
            get => roundAmount;
            set => this.RaiseAndSetIfChanged(ref roundAmount, value);
        }
        public string TournamentAmount
        {
            get => tournamentAmount;
            set => this.RaiseAndSetIfChanged(ref tournamentAmount, value);
        }
        public string EliminateReproduceAmount
        {
            get => eliminateReproduceAmount;
            set => this.RaiseAndSetIfChanged(ref eliminateReproduceAmount, value);
        }
        public string MistakeChance
        {
            get => mistakeChance;
            set => this.RaiseAndSetIfChanged(ref mistakeChance, value);
        }
        public ObservableCollection<Character> Characters { get; }

        public PrepareTournamentViewModel(MainWindowViewModel vm, PointsSystem ps, ObservableCollection<Character> participants)
        {
            Characters = participants;
            pointsSystem = ps;
            windowVM = vm;
            var proceedActive = this.WhenAnyValue(
                a => a.RoundAmount,
                b => b.TournamentAmount,
                c => c.EliminateReproduceAmount,
                d => d.MistakeChance,
                (a, b, c, d) => !string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b) && !string.IsNullOrWhiteSpace(c) && !string.IsNullOrWhiteSpace(d)
            );
            Proceed = ReactiveCommand.Create(ProceedTournament, proceedActive);
        }
        public ReactiveCommand<Unit, Unit> Proceed { get; }

        public void ProceedTournament()
        {
            Tournament tournament = new Tournament
            {
                RoundAmount = int.Parse(RoundAmount),
                TournamentAmount = int.Parse(TournamentAmount),
                EliminateReproduceAmount = int.Parse(EliminateReproduceAmount),
                MistakeChance = int.Parse(MistakeChance)
            };

            var vm = new TournamentResultsViewModel(windowVM, tournament, Characters);
            windowVM.Content = vm;
        }
    }
}
