// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace uFrame.ExampleProject {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.ExampleProject;
    using UniRx;
    using uFrame.Serialization;
    using uFrame.MVVM;
    
    
    public class LevelRootControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.IViewModelManager _LevelRootViewModelManager;
        
        [uFrame.IOC.InjectAttribute("LevelRoot")]
        public uFrame.MVVM.IViewModelManager LevelRootViewModelManager {
            get {
                return _LevelRootViewModelManager;
            }
            set {
                _LevelRootViewModelManager = value;
            }
        }
        
        public IEnumerable<LevelRootViewModel> LevelRootViewModels {
            get {
                return LevelRootViewModelManager.OfType<LevelRootViewModel>();
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeLevelRoot(((LevelRootViewModel)(viewModel)));
        }
        
        public virtual LevelRootViewModel CreateLevelRoot() {
            return ((LevelRootViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModel CreateEmpty() {
            return new LevelRootViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeLevelRoot(LevelRootViewModel viewModel) {
            // This is called when a LevelRootViewModel is created
            viewModel.LevelClose.Action = this.LevelCloseHandler;
            viewModel.LevelHotReload.Action = this.LevelHotReloadHandler;
            LevelRootViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            LevelRootViewModelManager.Remove(viewModel);
        }
        
        public virtual void LevelClose(LevelRootViewModel viewModel) {
        }
        
        public virtual void LevelHotReload(LevelRootViewModel viewModel) {
        }
        
        public virtual void LevelCloseHandler(LevelCloseCommand command) {
            this.LevelClose(command.Sender as LevelRootViewModel);
        }
        
        public virtual void LevelHotReloadHandler(LevelHotReloadCommand command) {
            this.LevelHotReload(command.Sender as LevelRootViewModel);
        }
    }
}
