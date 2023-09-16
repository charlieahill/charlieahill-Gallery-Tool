using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charlieahill_Gallery_Tool
{
    public class ResizingParams
    {
        /// <summary>Intiate a new set of resizing parameters</summary>
        /// <param name="inResizeMode">Choose either maintain aspect ratio, or crop to fit [default: maintain aspect ratio]</param>
        /// <param name="marMode">MAR Mode: Choose to define scaling ratio from height or width [default: Width] [not MAR Mode: leave blank]</param>
        /// <param name="cropMode">Crop Mode: Choose to define scaling ratio from height or width [default: Width] [not crop Mode: leave blank]</param>
        /// <param name="inMarWidth">MAR Mode + width: Choose target width [default: 100] [not MAR + width Mode: leave blank]</param>
        /// <param name="inMarHeight">MAR Mode + height: Choose target width [default: 100] [not MAR + height Mode: leave blank]</param>
        /// <param name="inCropScalingWidth">Crop Mode + width: Choose target width [default: 100] [not crop + width Mode: leave blank]</param>
        /// <param name="inCropScalingHeight">Crop Mode + height: Choose target height [default: 100] [not crop + height Mode: leave blank]</param>
        /// <param name="inCropTrimWidth">Crop Mode + height: Choose trim width [default: 100] [not crop + height Mode: leave blank]</param>
        /// <param name="inCropTrimHeight">Crop Mode + width: Choose trim height [default: 100] [not crop + width Mode: leave blank]</param>
        public ResizingParams(ResizeModeEnum inResizeMode = ResizeModeEnum.maintainAspect,
            MARModeEnum inMarMode = MARModeEnum.scaleToWidth,
            CropModeEnum cropMode = CropModeEnum.cropScaleToWidth,
            int inMarWidth = 100,
            int inMarHeight = 100,
            int inCropScalingWidth = 100,
            int inCropScalingHeight = 100,
            int inCropTrimWidth = 100,
            int inCropTrimHeight = 100)
        {
            resizeMode = inResizeMode;
            marMode = inMarMode;
            cropScalingMode = cropMode;
            marWidth = inMarWidth;
            marHeight = inMarHeight;
            cropScalingWidth = inCropScalingWidth;
            cropScalingHeight = inCropScalingHeight;
            cropTrimWidth = inCropTrimWidth;
            cropTrimHeight = inCropTrimHeight;
        }


        #region enumerations
        public enum ResizeModeEnum { maintainAspect, cropToFit };
        public enum MARModeEnum { scaleToHeight, scaleToWidth };
        public enum CropModeEnum { cropScaleToHeight, cropScaleToWidth };
        #endregion

        #region variables
        private ResizeModeEnum resizeMode;
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public ResizeModeEnum ResizeMode
        {
            get { return resizeMode; }
            set { resizeMode = value; }
        }

        private MARModeEnum marMode;
        /// <summary>Boolean - when in maintain aspect ratio mode - scale to width or height</summary>
        public MARModeEnum MarMode
        {
            get { return marMode; }
            set { marMode = value; }
        }

        private CropModeEnum cropScalingMode;
        /// <summary>Boolean - when in crop mode - scale to width or height</summary>
        public CropModeEnum CropScalingMode
        {
            get { return cropScalingMode; }
            set { cropScalingMode = value; }
        }

        private int marWidth;
        /// <summary>Integer - when in maintain aspect ratio mode - set the width to scale to</summary>
        public int MarWidth
        {
            get { return marWidth; }
            set { marWidth = value; }
        }
        
        private int marHeight;
        /// <summary>Integer - when in maintain aspect ratio mode - set the height to scale to</summary>
        public int MarHeight
        {
            get { return marHeight; }
            set { marHeight = value; }
        }

        private int cropScalingWidth;
        /// <summary>Integer - when in crop and scale mode - set the width to scale to</summary>
        public int CropScalingWidth
        {
            get { return cropScalingWidth; }
            set { cropScalingWidth = value; }
        }
        
        private int cropScalingHeight;
        /// <summary>Integer - when in crop and scale mode - set the height to scale to</summary>
        public int CropScalingHeight
        {
            get { return cropScalingHeight; }
            set { cropScalingHeight = value; }
        }

        private int cropTrimWidth;
        /// <summary>Integer - when in crop and scale mode - set the width to crop to</summary>
        public int CropTrimWidth
        {
            get { return cropTrimWidth; }
            set { cropTrimWidth = value; }
        }
        
        private int cropTrimHeight;
        /// <summary>Integer - when in crop and scale mode - set the height to crop to</summary>
        public int CropTrimHeight
        {
            get { return cropTrimHeight; }
            set { cropTrimHeight = value; }
        }
        #endregion
    }
}
