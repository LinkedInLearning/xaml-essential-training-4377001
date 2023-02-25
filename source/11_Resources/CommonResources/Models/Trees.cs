using System;
using System.Collections.ObjectModel;

namespace Models {

  internal class Trees : ObservableCollection<Tree> {

    public Trees() {
      this.Add(new Tree { TreeName = "Fir", MaxHeight = 90 });
      this.Add(new Tree { TreeName = "Oak", MaxHeight = 60 });
      this.Add(new Tree { TreeName = "Pine", MaxHeight = 85 });
      this.Add(new Tree { TreeName = "Palm", MaxHeight = 25 });
      this.Add(new Tree { TreeName = "Cedar", MaxHeight = 95 });

      
    }

    
  }
  internal class Tree {
    public string TreeName { get; set; }
    public int MaxHeight { get; set; }
  }
}