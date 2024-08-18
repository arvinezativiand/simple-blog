using Codeyad.CoreLayer.DTOs;
using Codeyad.CoreLayer.Services.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.Services.MainPage;

public interface IMainPageService
{
    MainPageDTO GetData();
}
