using EvolutionOfTrust.Characters;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace EvolutionUI.ViewModels
{
    class AddParticipantViewModel : ViewModelBase
    {
        public AddParticipantViewModel(int nextId)
        {
            Cancel = ReactiveCommand.Create(() => { });
            AddCheater = ReactiveCommand.Create(() => new Cheater(nextId));
            AddCopycat = ReactiveCommand.Create(() => new Copycat(nextId));
            AddCooperator = ReactiveCommand.Create(() => new Cooperator(nextId));
            AddGrudger = ReactiveCommand.Create(() => new Grudger(nextId));
            AddRandomJoker = ReactiveCommand.Create(() => new RandomJoker(nextId));
        }

        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public ReactiveCommand<Unit, Cheater> AddCheater { get; }
        public ReactiveCommand<Unit, Copycat> AddCopycat { get; }
        public ReactiveCommand<Unit, Cooperator> AddCooperator { get; }
        public ReactiveCommand<Unit, Grudger> AddGrudger { get; }
        public ReactiveCommand<Unit, RandomJoker> AddRandomJoker { get; }
    }
}
