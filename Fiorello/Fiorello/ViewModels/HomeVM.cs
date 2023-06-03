using Fiorello.Models;

namespace Fiorello.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> ? Sliders { get; set; }
        public SliderInfo ? SliderInfo { get; set; }

        public IEnumerable<Blog>? Blogs { get; set; }

        public BlogDetail ? BlogDetail { get; set; }

        public IEnumerable<Category>? Categories { get; set; }

        public IEnumerable<Product>? Products { get; set; }

        public About ? About { get; set; }

        public IEnumerable<Expert>? Experts { get; set; }
        public IEnumerable<Start>? Starts { get; set; }

        public IEnumerable<Instagram>? Instagram { get; set; }

    }
}
