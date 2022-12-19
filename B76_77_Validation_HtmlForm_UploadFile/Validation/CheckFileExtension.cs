// Seach Google: FileExtension Attribute source gitthub
// https://github.com/microsoft/referencesource/blob/master/System.ComponentModel.DataAnnotations/DataAnnotations/FileExtensionsAttribute.cs


using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class CheckFileExtension : DataTypeAttribute {
        private string _extensions;

        public CheckFileExtension() : base(DataType.Upload) {

            // DevDiv 468241: set DefaultErrorMessage not ErrorMessage, allowing user to set
            // ErrorMessageResourceType and ErrorMessageResourceName to use localized messages.
            ErrorMessage = "Chỉ được định nghĩa các file trong {1}";
        }

        public string Extensions {
            get {
                // Default file extensions match those from jquery validate.
                return String.IsNullOrWhiteSpace(_extensions) ? "png,jpg,jpeg,gif" : _extensions;
            }
            set {
                _extensions = value;
            }
        }

        private string ExtensionsFormatted {
            get {
                return ExtensionsParsed.Aggregate((left, right) => left + ", " + right);
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "These strings are normalized to lowercase because they are presented to the user in lowercase format")]
        private string ExtensionsNormalized {
            get {
                return Extensions.Replace(" ", "").Replace(".", "").ToLowerInvariant();
            }
        }

        private IEnumerable<string> ExtensionsParsed {
            get {
                return ExtensionsNormalized.Split(',').Select(e => "." + e);
            }
        }

        public override string FormatErrorMessage(string name) {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, ExtensionsFormatted);
        }

        public override bool IsValid(object value) {
            if (value == null) {
                return true;
            }

            // Kiểm tra xem object gởi đến có phải là một file hay không
            IFormFile file = value as IFormFile;
            if(file != null)
            {
                var fileName = file.FileName;
                return ValidateExtension(fileName); // Check xem file có phù hợp hay không
            }

            string valueAsString = value as string;
            if (valueAsString != null) {
                return ValidateExtension(valueAsString);
            }

            return false;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "These strings are normalized to lowercase because they are presented to the user in lowercase format")]
        private bool ValidateExtension(string fileName) {
            try {
                return ExtensionsParsed.Contains(Path.GetExtension(fileName).ToLowerInvariant());
            }
            catch (ArgumentException) {
                return false;
            }
        }
    }