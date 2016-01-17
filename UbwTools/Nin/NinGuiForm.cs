using NinEngine;
using System;
using System.Windows.Forms;
using UbwTools.Common;
using UbwTools.Common.Gui;
using UbwTools.Properties;

namespace UbwTools.Nin
{
    public partial class NinGuiForm : FormBase
    {
        public NinGuiForm()
        {
            InitializeComponent();
            Icon = Resources.NorIdNum;
            RestoreWindowInfo();
        }

        private void NinGuiForm_Load(object sender, EventArgs e)
        {
            comboBoxGenerateWhat.SelectedIndex = 0;
            comboBoxVaryUsing.SelectedIndex = 0;
            comboBoxGender.SelectedIndex = 0;
            textBoxVerifyNumber.Select();
            textBoxVerifyNumber.Focus();
            this.Activate();
        }

        private void NinGuiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (new WaitingCursor())
            {
                SaveWindowInfo();
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void menuHelpUsersGuide_Click(object sender, EventArgs e)
        {
            Util.OpenDocument(this, "UBW Tools - Brukermanual.pdf");
        }

        private void verifyControl_Enter(object sender, EventArgs e)
        {
            AcceptButton = buttonVerify;
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            string number = textBoxVerifyNumber.Text.Trim();
            if (radioButtonVerifyOrganizationNumber.Checked)
            {
                VerifyOrganizationNumber(number);
            }
            else if (radioButtonVerifyBirthNumber.Checked)
            {
                VerifyBirthNumber(number);
            }
            else if (radioButtonVerifyDNumber.Checked)
            {
                VerifyDNumber(number);
            }
            else
            {
                VerifyUnknownKindOfNumber(number);
            }
        }

        private void generateControl_Enter(object sender, EventArgs e)
        {
            AcceptButton = buttonGenerate;
        }

        private void comboBoxGenerateWhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustControlsBasedOnWhatToGenerate();
        }

        private void comboBoxVaryUsing_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustControlsBasedOnWhatToVaryOn();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            switch (comboBoxGenerateWhat.SelectedIndex)
            {
                case 0:
                    GenerateOrganizationNumber();
                    break;
                case 1:
                    GenerateBirthNumber();
                    break;
                case 2:
                    GenerateDNumber();
                    break;
            }
        }

        private void AdjustControlsBasedOnWhatToGenerate()
        {
            if (0 == comboBoxGenerateWhat.SelectedIndex)
            {
                comboBoxVaryUsing.SelectedIndex = 0;
                AdjustControlsForGeneratingOrganisationNumber();
            }
            else
            {
                AdjustControlsForGeneratingBirthNumberOrDNumber();
            }
        }

        private void AdjustControlsBasedOnWhatToVaryOn()
        {
            bool usePattern = (0 == comboBoxVaryUsing.SelectedIndex);
            bool useDatesAndGender = !usePattern;
            EnablePattern(usePattern);
            EnableDatesAndGenderControls(useDatesAndGender);
        }

        private void AdjustControlsForGeneratingOrganisationNumber()
        {
            EnableVaryUsing(false);
            EnablePattern(true);
            EnableDatesAndGenderControls(false);
        }

        private void AdjustControlsForGeneratingBirthNumberOrDNumber()
        {
            EnableVaryUsing(true);
            AdjustControlsBasedOnWhatToVaryOn();
        }

        private void EnableVaryUsing(bool enable)
        {
            comboBoxVaryUsing.Enabled = enable;
        }

        private void EnablePattern(bool enable)
        {
            textBoxPattern.Enabled = enable;
        }

        private void EnableDatesAndGenderControls(bool enable)
        {
            dateTimePickerFrom.Enabled = enable;
            dateTimePickerTo.Enabled = enable;
            comboBoxGender.Enabled = enable;
        }

        private void VerifyOrganizationNumber(string number)
        {
            try
            {
                // ReSharper disable once UnusedVariable
                OrganizationNumber on = new OrganizationNumber(number);
                ShowResult("Organisasjonsnummer", string.Format("{0} er et gyldig organisasjonsnummer.", number));
            }
            catch (NinException ex)
            {
                ShowResult("Organisasjonsnummer", ex.Message, true);
            }
        }

        private void VerifyBirthNumber(string number)
        {
            try
            {
                // ReSharper disable once UnusedVariable
                BirthNumber bn = new BirthNumber(number);
                ShowResult("Fødselsnummer", string.Format("{0} er et gyldig fødselsnummer.", number));
            }
            catch (NinException ex)
            {
                ShowResult("Fødselsnummer", ex.Message, true);
            }
        }

        private void VerifyDNumber(string number)
        {
            try
            {
                // ReSharper disable once UnusedVariable
                DNumber dn = new DNumber(number);
                ShowResult("D-nummer", string.Format("{0} er et gyldig D-nummer.", number));
            }
            catch (NinException ex)
            {
                ShowResult("D-nummer", ex.Message, true);
            }
        }

        private void VerifyUnknownKindOfNumber(string number)
        {
            OrganizationNumber on = OrganizationNumber.Create(number);
            if (on != null)
            {
                ShowResult("Organisasjonsnummer", string.Format("{0} er et gyldig organisasjonsnummer.", number));
                return;
            }

            BirthNumber bn = BirthNumber.Create(number);
            if (bn != null)
            {
                ShowResult("Fødselsnummer", string.Format("{0} er et gyldig fødselsnummer.", number));
                return;
            }

            DNumber dn = DNumber.Create(number);
            if (dn != null)
            {
                ShowResult("D-nummer", string.Format("{0} er et gyldig D-nummer.", number));
                return;
            }

            ShowResult("Identitetsnummer",
                string.Format(
                    "{0} gjenkjennes ikke. Det er ikke et gyldig organisasjonsnummer, fødselsnummer eller D-nummer.", number),
                true);
        }

        private void GenerateOrganizationNumber()
        {
            string pattern = textBoxPattern.Text.Trim();
            try
            {
                OrganizationNumber orgNo = string.IsNullOrEmpty(pattern)
                    ? OrganizationNumber.OneRandom()
                    : OrganizationNumber.OneRandom(pattern);
                ShowGenerated(orgNo);
            }
            catch (NinException ex)
            {
                ShowResult("Feil", string.Format("Klarer ikke å generere organisasjonsnummer:\r\n{0}", ex.Message), true);
            }
        }

        private void GenerateBirthNumber()
        {
            try
            {
                if (0 == comboBoxVaryUsing.SelectedIndex)
                {
                    string pattern = textBoxPattern.Text.Trim();
                    BirthNumber birthNo = string.IsNullOrEmpty(pattern)
                        ? BirthNumber.OneRandom()
                        : BirthNumber.OneRandom(pattern);
                    ShowGenerated(birthNo);
                }
                else
                {
                    GenderRequest gender;
                    switch (comboBoxGender.SelectedIndex)
                    {
                        case 1:
                            gender = GenderRequest.Female;
                            break;
                        case 2:
                            gender = GenderRequest.Male;
                            break;
                        default:
                            gender = GenderRequest.Any;
                            break;
                    }
                    BirthNumber birthNo = BirthNumber.OneRandom(dateTimePickerFrom.Value, dateTimePickerTo.Value, gender);
                    ShowGenerated(birthNo);
                }
            }
            catch (NinException ex)
            {
                ShowResult("Feil", string.Format("Klarer ikke å generere fødselsnummer:\r\n{0}", ex.Message), true);
            }
        }

        private void GenerateDNumber()
        {
            try
            {
                if (0 == comboBoxVaryUsing.SelectedIndex)
                {
                    string pattern = textBoxPattern.Text.Trim();
                    DNumber dNo = string.IsNullOrEmpty(pattern)
                        ? DNumber.OneRandom()
                        : DNumber.OneRandom(pattern);
                    ShowGenerated(dNo);
                }
                else
                {
                    GenderRequest gender;
                    switch (comboBoxGender.SelectedIndex)
                    {
                        case 1:
                            gender = GenderRequest.Female;
                            break;
                        case 2:
                            gender = GenderRequest.Male;
                            break;
                        default:
                            gender = GenderRequest.Any;
                            break;
                    }
                    DNumber dNo = DNumber.OneRandom(dateTimePickerFrom.Value, dateTimePickerTo.Value, gender);
                    ShowGenerated(dNo);
                }
            }
            catch (NinException ex)
            {
                ShowResult("Feil", string.Format("Klarer ikke å generere D-nummer:\r\n{0}", ex.Message), true);
            }
        }

        private void ShowGenerated(IdNumberBase id)
        {
            if (null == id)
            {
                ShowResult("Feil",
                    "Klarer ikke å generere: For mange forsøk. Sannsynligvis på grunn av et mønster som gjør det umulig å generere et lovlig nummer.",
                    true);
            }
            else
            {
                Clipboard.SetText(id.Number);
                ShowResult(id.Name,
                    string.Format(
                        "Generert nummer: {0}\r\n\r\nNummeret er kopiert til utklippstavlen, og kan limes inn i andre programmer derfra.",
                        id.Number));
            }
        }

        private void ShowResult(string title, string message, bool failure = false)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK,
                failure ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }
    }
}
