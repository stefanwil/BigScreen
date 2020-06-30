using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BigScreen.Data;
using BigScreen.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BigScreen.Pages
{

    [ValidateAntiForgeryToken]
    public class WindowSizeModel : PageModel

    {
        private readonly BigScreenContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public WindowSizeModel(IHostingEnvironment environment,
            BigScreenContext context)
        {

            _context = context;
            hostingEnvironment = environment;
        }

        [BindProperty]
        public string DeviceId { get; set; }
        [BindProperty]
        public string Width { get; set; }
        [BindProperty]
        public string Height { get; set; }
        [BindProperty]
        public string DevicePixelRatio { get; set; }

     
        public JsonResult OnGetList()
        {
            List<string> lstString = new List<string>
            {
                "Val 1"

            };
            return new JsonResult(lstString);

        }
     
     
        public IActionResult OnPost()
        //public JsonResult OnSetDevice([Bind("DeviceId,Height,Width")]  WindowSizeModel windowSizeModel)
        {
            if (ModelState.IsValid)
            {
                var deviceId = DeviceId;
                var height = Height;
                var width = Width;
                Response.Cookies.Append("rectHeight", height.ToString());  // stefan set test cookie
                Response.Cookies.Append("rectWidth", width.ToString());  // stefan set test cookie



                //var settingroot = Path.Combine(hostingEnvironment.WebRootPath, "settings");



                //JsonSerializer serializer = new JsonSerializer();
                //serializer.Converters.Add(new JavaScriptDateTimeConverter());
                //serializer.NullValueHandling = NullValueHandling.Ignore;

                //using (StreamWriter sw = new StreamWriter(settingroot + "/json.txt"))
                //using (JsonWriter writer = new JsonTextWriter(sw))
                //{
                //    serializer.Serialize(writer, setting);
                //    // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }


            //return new JsonResult(DeviceId);
            return Page();

        }
        public async Task<IActionResult> OnPostSendAsync()
        //public ActionResult OnPostSend()
        {
            var cookieValue = Request.Cookies["MyCookie"]; //Read Test vccokie/Stefan
            var deviceWindow = new DeviceWindow();
            var Tifodisplay = new TifoPartScreen();
            var devices = new List<DeviceWindow>();
            string sPostValue0 = "";
            string sPostValue1 = "";
            string sPostValue2 = "";
            string sPostValue3 = "";
            string sPostValue4 = "";
            Response.Cookies.Append("MyCookie", "value1");  // stefan set test cookie

            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<DeviceWindow>(requestBody);
                        if (obj != null)
                        {
                            sPostValue0 = obj.DeviceId;
                            sPostValue1 = obj.Width;
                            sPostValue2 = obj.Height;
                            sPostValue3 = obj.DevicePixelRatio;
                            sPostValue4 = obj.DotsPerInch;
                            deviceWindow = obj;
                           
                            Tifodisplay.DotsPerPixel = Convert.ToDouble(obj.DevicePixelRatio);
                            Tifodisplay.TifoPartScreenHeight = (int)(Convert.ToInt32(obj.Height) * Tifodisplay.DotsPerPixel);
                            Tifodisplay.TifoPartScreenWidth = (int)(Convert.ToInt32(obj.Width) * Tifodisplay.DotsPerPixel);
                            Tifodisplay.DotsPerInch = Convert.ToInt32(obj.DotsPerInch);
                            Tifodisplay.AbsScreenHeight =  Convert.ToInt32(obj.Height) / Tifodisplay.DotsPerInch* 254/10;
                            Tifodisplay.AbsScreenWidth = Convert.ToInt32(obj.Width) / Tifodisplay.DotsPerInch * 254/10;
                            //_context.TifoPartScreen.Add(Tifodisplay);  Flyttat
                            //await _context.SaveChangesAsync();
                        }
                    }
                }





                var devicesroot = Path.Combine(hostingEnvironment.WebRootPath, "devices");

                JsonSerializer serializer = new JsonSerializer();


                serializer.NullValueHandling = NullValueHandling.Ignore;



                using (StreamReader sw1 = new StreamReader(devicesroot + "/devices1.txt"))
                using (JsonReader reader = new JsonTextReader(sw1))
                {

                    devices = serializer.Deserialize<List<DeviceWindow>>(reader);
                    if (devices != null)
                    {

                        if (devices.Where(deviceWindowinList => deviceWindowinList.DeviceId == deviceWindow.DeviceId).Any() == false)
                        {
                            var newdeviceWindow1 = new DeviceWindow()
                            {
                                DeviceId = deviceWindow.DeviceId,
                                Width = deviceWindow.Width,
                                Height = deviceWindow.Height,
                                DevicePixelRatio = deviceWindow.DevicePixelRatio,
                                DotsPerInch=deviceWindow.DotsPerInch

                            };

                            devices.Add(newdeviceWindow1);
                            // {"ExpiryDate":new Date(1230375600000),"Price":0}
                            _context.TifoPartScreen.Add(Tifodisplay);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        var newdeviceWindow1 = new DeviceWindow()
                        {
                            DeviceId = deviceWindow.DeviceId,
                            Width = deviceWindow.Width,
                            Height = deviceWindow.Height,
                            DevicePixelRatio = deviceWindow.DevicePixelRatio,
                             DotsPerInch = deviceWindow.DotsPerInch

                        };
                        devices = new List<DeviceWindow>
                        {
                            newdeviceWindow1
                        };
                        _context.TifoPartScreen.Add(Tifodisplay);
                        await _context.SaveChangesAsync();
                    }


                }



                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(devicesroot + "/devices1.txt"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, devices);
                    // {"ExpiryDate":new Date(1230375600000),"Price":0}
                }

            }
            List<string> lstString = new List<string>
            {
                sPostValue0,
                sPostValue1,
                sPostValue2,
                sPostValue3,
                sPostValue4

            };
            return new JsonResult(lstString);
        }





    }

}