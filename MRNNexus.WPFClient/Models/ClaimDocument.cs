using MRNNexusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNNexus.WPFClient.Models
{
    internal class ClaimDocument
    {
        #region Fields
        private int _documentID;
        private int _docTypeID;
        private int _claimID;
        private string _filePath;
        private string _fileName;
        private string _fileBytes;
        private string _fileExt;
        private DateTime _documentDate;
        private string _signatureImagePath;
        private int? _numSignatures;
        private string _initialImagePath;
        private int? _numInitials;
        #endregion

        #region Properties
        public int DocumentID
        {
            get
            {
                return _documentID;
            }

            set
            {
                _documentID = value;
            }
        }

        public int DocTypeID
        {
            get
            {
                return _docTypeID;
            }

            set
            {
                _docTypeID = value;
            }
        }

        public int ClaimID
        {
            get
            {
                return _claimID;
            }

            set
            {
                _claimID = value;
            }
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }

            set
            {
                _filePath = value;
            }
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                _fileName = value;
            }
        }

        public string FileBytes
        {
            get
            {
                return _fileBytes;
            }

            set
            {
                _fileBytes = value;
            }
        }

        public string FileExt
        {
            get
            {
                return _fileExt;
            }

            set
            {
                _fileExt = value;
            }
        }

        public DateTime DocumentDate
        {
            get
            {
                return _documentDate;
            }

            set
            {
                _documentDate = value;
            }
        }

        public string SignatureImagePath
        {
            get
            {
                return _signatureImagePath;
            }

            set
            {
                _signatureImagePath = value;
            }
        }

        public int? NumSignatures
        {
            get
            {
                return _numSignatures;
            }

            set
            {
                _numSignatures = value;
            }
        }

        public string InitialImagePath
        {
            get
            {
                return _initialImagePath;
            }

            set
            {
                _initialImagePath = value;
            }
        }

        public int? NumInitials
        {
            get
            {
                return _numInitials;
            }

            set
            {
                _numInitials = value;
            }
        }
        #endregion

        #region Constructors
        public ClaimDocument() { }

        public ClaimDocument(DTO_ClaimDocument c)
        {
            DocumentID = c.DocumentID;
            DocTypeID = c.DocTypeID;
            ClaimID = c.ClaimID;
            FilePath = c.FilePath;
            FileName = c.FileName;
            FileBytes = c.FileBytes;
            FileExt = c.FileExt;
            DocumentDate = c.DocumentDate;
            SignatureImagePath = c.SignatureImagePath;
            NumSignatures = c.NumSignatures;
            InitialImagePath = c.InitialImagePath;
            NumInitials = c.NumInitials;           
        }
        #endregion

        public DTO_ClaimDocument toDTO()
        {
            return new DTO_ClaimDocument
            {
                DocumentID = this.DocumentID,
                DocTypeID = this.DocTypeID,
                ClaimID = this.ClaimID,
                FilePath = this.FilePath,
                FileName = this.FileName,
                FileBytes = this.FileBytes,
                FileExt = this.FileExt,
                DocumentDate = this.DocumentDate,
                SignatureImagePath = this.SignatureImagePath,
                NumSignatures = this.NumSignatures,
                InitialImagePath = this.InitialImagePath,
                NumInitials = this.NumInitials,
            };
        }
    }
}
