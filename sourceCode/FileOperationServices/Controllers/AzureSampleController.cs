using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Samples.BLL;
using WebAPI.Samples.Model;

namespace WebAPI.Samples.API
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AzureSampleController : ControllerBase
    {
        AzureOperationBLL azureOperationBLL = new AzureOperationBLL();

        [Route("UploadFiles")]
        [HttpPost]
        public async Task<ActionResult> MultipartUploadFileAsync([FromHeader] string metadata, [FromForm] List<IFormFile> file)
        {
            // {"folderID": "Test1","docType": "string","saveName": "string"}
            try
            {
                if (file != null)
                {
                    bool status = await azureOperationBLL.UploadFile(metadata, file);
                    return Ok(status);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }



        [Route("GetFile")]
        [HttpPost]
        public async Task<ActionResult> GetFileBase64(AzureFileDetails file)
        {
            try
            {
                if (file != null)
                {
                    //Decrypt("LYICfcKtCfC+FeFCJ7hkKvlT/ShZpzVmAgv8tg9bSOFqHya5xPLIqoVzRL2YaKfN73ZuHSAQkVEW5LpMepRXDA==");
                    test test = new();
                    test.dd();
                    test.DecryptStringFromBytes(Encoding.UTF8.GetBytes("LYICfcKtCfC+FeFCJ7hkKvlT/ShZpzVmAgv8tg9bSOFqHya5xPLIqoVzRL2YaKfN73ZuHSAQkVEW5LpMepRXDA=="), "e44bc1099e7c088fe04043d3ee22d4d928ef9215");
                    using (AesManaged aes = new AesManaged())
                    {
                        //string decrypted = test.Decryptv3( Encoding.UTF8.GetBytes("LYICfcKtCfC+FeFCJ7hkKvlT/ShZpzVmAgv8tg9bSOFqHya5xPLIqoVzRL2YaKfN73ZuHSAQkVEW5LpMepRXDA=="), aes.Key, aes.IV);
                    }

                        // var File = await azureOperationBLL.GetFile(file);
                        return Ok();
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        





        [Route("Traverse_A_Share")]
        [HttpPost]
        //List all file and directories in a share
        public async Task<ActionResult> TraverseaShare(AzureFileDetails file)
        {
            try
            {
                if (file != null)
                {
                    azureOperationBLL.TraverseaShare(file);
                    return Ok();
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }





        [Route("UploadFileBLOB")]
        [HttpPost]
        public async Task<ActionResult> UploadFile([FromHeader] string metadata, [FromForm] List<IFormFile> file)
        {
            // {"folderID": "Test1","docType": "string","saveName": "string"}
            try
            {
                if (file != null)
                {
                    bool status = await azureOperationBLL.UploadFileBlob(metadata, file);
                    return Ok(status);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }



        [Route("GetFileBLOB")]
        [HttpPost]
        public async Task<ActionResult> DownloadFileBlob(AzureFileDetails file)
        {
            try
            {
                if (file != null)
                {
                    //var File = await azureOperationBLL.GetFileBlob(file);
                    var File = "";
                    return Ok(File);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }







        [Route("ListaBLOB")]
        [HttpPost]
        //List all file and directories in a share
        public async Task<ActionResult> ListBlob(AzureFileDetails file, string containerName)
        {
            try
            {
                if (file != null)
                {
                    var details = azureOperationBLL.ListBlobAsync(file, containerName);
                    return Ok();
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }









        [Route("haotest")]
        [HttpPost]
        //List all file and directories in a share
        public ActionResult haotest(int Testnumber)
        {
            try
            {
                if (Testnumber != null)
                {
                    var details = azureOperationBLL.haotest(Testnumber);
                    return Ok(details);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }

}
