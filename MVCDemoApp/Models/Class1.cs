using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;



namespace MVCDemoApp.Models
{
    public class class1
    {
        //public void TestPPT()
        //{
        //    string pictureFileName = @"D:\Vinay\Data\MVCDemoApp\MVCDemoApp\Upload\AddNewUser.png";

        //    Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();


        //    Microsoft.Office.Interop.PowerPoint.Slides slides;
        //    Microsoft.Office.Interop.PowerPoint._Slide slide;
        //    Microsoft.Office.Interop.PowerPoint.TextRange objText;

        //    // Create the Presentation File
           
        //  // Presentation pptPresentation= pptApplication.Presentations.Add(MsoTriState.msoTrue);
        //   Presentation pptPresentation = pptApplication.Presentations.Add(MsoTriState.msoCTrue);

        
        //    Microsoft.Office.Interop.PowerPoint.CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];

        //    // Create new Slide
        //    slides = pptPresentation.Slides;
        //    slide = slides.AddSlide(1, customLayout);

        //    // Add title
        //    objText = slide.Shapes[1].TextFrame.TextRange;
        //    objText.Text = "FPPT.com";
        //    objText.Font.Name = "Arial";
        //    objText.Font.Size = 32;

        //    objText = slide.Shapes[2].TextFrame.TextRange;
        //    objText.Text = "Content goes here\nYou can add text\nItem 3";

        //    Microsoft.Office.Interop.PowerPoint.Shape shape = slide.Shapes[2];
            
        //  //  slide.Shapes.AddPicture(pictureFileName, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, shape.Left, shape.Top, shape.Width, shape.Height);

        //    slide.NotesPage.Shapes[2].TextFrame.TextRange.Text = "This demo is created by FPPT using C# - Download free templates from http://FPPT.com";



        //  //  pptPresentation.SaveAs(@"D:\Vinay\Data\MVCDemoApp\MVCDemoApp\Upload\fppt.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
        //    //pptPresentation.Close();
        //    //pptApplication.Quit();

        //}
    }
}
