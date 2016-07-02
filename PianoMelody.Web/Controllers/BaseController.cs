namespace PianoMelody.Web.Controllers
{
    using System.Web.Mvc;

    using PianoMelody.Data;
    using PianoMelody.Data.Contracts;
    using PianoMelody.Web.Extensions;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new PianoMelodyData())
        {
        }

        public BaseController(IPianoMelodyData data)
        {
            this.Data = data;
        }

        public IPianoMelodyData Data { get; set; }
    }
}