using EvolutionOfTrust;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EvolutionUI.ViewModels
{
    class TournamentResultsViewModel : ViewModelBase
    {
        Tournament tournament;
        MainWindowViewModel windowVM;

        Tournament Tournament
        {
            get => tournament;
            set => this.RaiseAndSetIfChanged(ref tournament, value);
        }

        public ObservableCollection<Character> Characters { get; }
        public TournamentResultsViewModel(MainWindowViewModel mv, Tournament t, ObservableCollection<Character> participants)
        {
            tournament = t;
            windowVM = mv;
            Characters = participants;
            tournament.PlayTournaments(new List<Character>((IEnumerable<Character>)Characters), out _);
        }

        public void Reset()
        {
            windowVM.Content = new StartViewModel();
        }
    }
}
