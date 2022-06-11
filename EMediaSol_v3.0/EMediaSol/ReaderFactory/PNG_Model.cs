using EMediaSol.ReaderFactory.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class PNG_Model
    {
        public IHDR_Chunk _IHDR_Chunk ;
        public PLTE_Chunk _PLTE_Chunk ;
        public IDAT_Chunk _IDAT_Chunk ;
        public IEND_Chunk _IEND_Chunk ;
        public cHRM_Chunk _cHRM_Chunk ;
        public gAMA_Chunk _gAMA_Chunk ;
        public sBIT_Chunk _sBIT_Chunk ;
        public sRGB_Chunk _sRGB_Chunk ;
        public bKGD_Chunk _bKGD_Chunk ;
        public pHYs_Chunk _pHYs_Chunk ;
        public iTXt_Chunk _iTXt_Chunk ;
        public tEXt_Chunk _tEXt_Chunk ;
        public zTXt_Chunk _zTXt_Chunk ;
        public PNG_Model(string path)
        {
            _init_(path);
        }

        public void _init_(string png_file_path)
        {
            byte[] inputArray = new PngBitReader().ReadPngFile(png_file_path);
            _IHDR_Chunk = new IHDR_Chunk(inputArray);
            _PLTE_Chunk = new PLTE_Chunk(inputArray);
            _IDAT_Chunk = new IDAT_Chunk(inputArray);
            _IEND_Chunk = new IEND_Chunk(inputArray);
            _cHRM_Chunk = new cHRM_Chunk(inputArray);
            _gAMA_Chunk = new gAMA_Chunk(inputArray);
            _sBIT_Chunk = new sBIT_Chunk(inputArray);
            _sRGB_Chunk = new sRGB_Chunk(inputArray);
            _bKGD_Chunk = new bKGD_Chunk(inputArray);
            _pHYs_Chunk = new pHYs_Chunk(inputArray);
            _iTXt_Chunk = new iTXt_Chunk(inputArray);
            _tEXt_Chunk = new tEXt_Chunk(inputArray);
            _zTXt_Chunk = new zTXt_Chunk(inputArray);
        }

        public void SaveModel(string destination_file_path)
        {
            byte[] header = { 137, 80, 78, 71, 13, 10, 26, 10 };
            _IHDR_Chunk.DeleteFile(destination_file_path);
            _IHDR_Chunk.AppendAllBytes(destination_file_path, header);

            _IHDR_Chunk.AppendChunkBytesToFile(destination_file_path);
            _PLTE_Chunk.AppendChunkBytesToFile(destination_file_path);
            _IDAT_Chunk.AppendChunkBytesToFile(destination_file_path);
            _cHRM_Chunk.AppendChunkBytesToFile(destination_file_path);
            _gAMA_Chunk.AppendChunkBytesToFile(destination_file_path);
            _sBIT_Chunk.AppendChunkBytesToFile(destination_file_path);
            _sRGB_Chunk.AppendChunkBytesToFile(destination_file_path);
            _bKGD_Chunk.AppendChunkBytesToFile(destination_file_path);
            _pHYs_Chunk.AppendChunkBytesToFile(destination_file_path);
            _iTXt_Chunk.AppendChunkBytesToFile(destination_file_path);
            _tEXt_Chunk.AppendChunkBytesToFile(destination_file_path);
            _zTXt_Chunk.AppendChunkBytesToFile(destination_file_path);
            _IEND_Chunk.AppendChunkBytesToFile(destination_file_path);
        }
    }
}
