using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace EvolutionUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        public ViewModelBase Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }
        public MainWindowViewModel()
        {
            Content = new StartViewModel();
        }

        public void Start()
        {
            var vm = new PointSystemViewModel();

            vm.Proceed.Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        Content = new ParticipantsViewModel(this, model);
                    }

                });

            Content = vm;
        }
    }
}
