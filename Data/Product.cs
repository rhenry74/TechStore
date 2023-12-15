using System.Collections.Generic;

namespace Data;

public class Product: Container
{
    public string Title { get; set; }
    public string Locator { get; set; }
    public string Description { get; set; }
    public List<Bullit> Bullits { get; set; } = new List<Bullit>();
    public List<Image> Images { get; set; } = new List<Image>();
    public List<Artifact> Artifacts { get; set; } = new List<Artifact>();
    public Firmware Firmware { get; set; }
    public User Owner {  get; set; }
    public Image Diagram {  get; set; }

}
