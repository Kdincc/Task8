﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.ViewModels
{
    public class GroupEditViewModel
    {
        private readonly IGroupEditModel _model;

        public GroupEditViewModel(IGroupEditModel model, IEventAggregator eventAggregator)
        {
            _model = model;
        }

        public ObservableCollection<Student> Students => new(_model.Students);
    }
}
