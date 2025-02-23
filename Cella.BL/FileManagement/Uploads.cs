
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WarehouseDal.Models;
using System.Net;
using FluentFTP;
using Warehouse.BL.Helpers;

namespace MISSystem.BL.FileManagement {
    public class FileUploads {
        public enum UploadType {
            FTP = 1,
            FOLDER = 2,
            SERVER = 3


        }

        public string FTPHostName { get; set; }
        public string FTPUserName { get; set; }
        public string FTPPassword { get; set; }


        public string FtpFolderDestination { get; set; }
        private async Task<bool> FtpUpLoadListAsync(List<FileAttachmentsVM> fileAttachments) {

            // create an FTP client
            FtpClient client = new FtpClient(FTPHostName);

            // specify the login credentials, unless you want to use the "anonymous" user account
            client.Credentials = new NetworkCredential(FTPUserName, FTPPassword);

            // begin connecting to the server
            client.Connect();

            foreach (var item in fileAttachments) {
                await client.UploadFileAsync(item.FullPath, FtpFolderDestination + item.File);
            }
            client.Disconnect();

            return false;
        }
        private async Task<bool> FtpUpLoadAsync(FileAttachmentsVM fileAttachments) {

            // create an FTP client
            FtpClient client = new FtpClient(FTPHostName);

            // specify the login credentials, unless you want to use the "anonymous" user account
            client.Credentials = new NetworkCredential(FTPUserName, FTPPassword);

            // begin connecting to the server
            client.Connect();
            await client.UploadFileAsync(fileAttachments.FullPath, FtpFolderDestination + fileAttachments.File);
            client.Disconnect();

            return false;
        }

        public async Task<bool> Upload(FileAttachmentsVM fileAttachments, UploadType uploadType) {
            string ServerLocation = AppConfiguration.Instance.FileUploadPath;
            string folderLocation = Path.Combine(ServerLocation + fileAttachments.File);
            
                //this is only if the permission has correct permissions it should be either a map drive 
                // or a unc path with apporpiate user permissions
                if (uploadType == UploadType.SERVER) {
                    await fileAttachments.File.CopyToAsync(new FileStream(fileAttachments.DocumentPath, FileMode.Create));

                }
                if (uploadType == UploadType.FOLDER) {

                    await fileAttachments.File.CopyToAsync(new FileStream(folderLocation, FileMode.Create));

                }

                if (uploadType == UploadType.FTP) {
                    await FtpUpLoadAsync(fileAttachments);
                }
                return true;
 
            }

        }
    }
    
