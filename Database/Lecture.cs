using System;
using System.Collections.Generic;

namespace schoolmangment.MVC.Database;

public partial class Lecture
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;
}
