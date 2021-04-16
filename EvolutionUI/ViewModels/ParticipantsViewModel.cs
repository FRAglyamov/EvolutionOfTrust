using EvolutionOfTrust;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace EvolutionUI.ViewModels
{
    class ParticipantsViewModel : ViewModelBase
    {
        PointsSystem pointSystem;
        MainWindowViewModel windowVM;
        int nextId = 1;
        int itemsAdded = 0;

        public int NextId
        {
            get => nextId;
        }
        public PointsSystem PointSystem
        {
            get => pointSystem;
            private set => this.RaiseAndSetIfChanged(ref pointSystem, value);
        }

        public ObservableCollection<Character> Characters { get; }

        public ParticipantsViewModel(MainWindowViewModel vm, PointsSystem ps)
        {
            windowVM = vm;
            pointSystem = ps;
            Characters = new ObservableCollection<Character>();

            DoPrepareTournament = ReactiveCommand.Create(PrepareTournament);
        }
        public ReactiveCommand<Unit, Unit> DoPrepareTournament { get; }
        public void AddParticipant()
        {
            var vm = new AddParticipantViewModel(nextId);

            Observable.Merge(
                    vm.Cancel.Select(_ => (Character)null),
                    vm.AddCheater,
                    vm.AddCooperator,
                    vm.AddCopycat,
                    vm.AddGrudger,
                    vm.AddRandomJoker)
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        nextId++;
                        Characters.Add(model);
                    }
                    Console.WriteLine(Characters.Count());
                    itemsAdded = Characters.Count();
                    windowVM.Content = this;
                });

            windowVM.Content = vm;
        }

        public void Remove(string id)
        {
            int removalId = int.Parse(id);
            Characters.Remove(Characters.Where(x => x.id == removalId).Single());
            itemsAdded = Characters.Count();
        }

        public void PrepareTournament()
        {
            windowVM.Content = new PrepareTournamentViewModel(windowVM, pointSystem, Characters);
        }
    }
}
