using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Parse user input
				if (double.TryParse(LoanAmountTextBox.Text, out double loanAmount) &&
					double.TryParse(InterestRateTextBox.Text, out double interestRate) &&
					int.TryParse(LoanTermTextBox.Text, out int loanTermYear) &&
					int.TryParse(LoanTermMonthsTextBox.Text, out int loanTermMonth))
				{
					// Calculate the monthly interest rate
					double monthlyInterestRate = interestRate / 12 / 100;

					// Calculate the number of monthly payments
					int numberOfPayments = (loanTermYear + loanTermMonth) * 12;

					// Calculate the monthly mortgage payment
					double monthlyPayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments)) /
											(Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);

					// Display the result
					MonthlyInterestRateTextBox.Text = monthlyInterestRate.ToString();
					MonthlyRepaymentTextBox.Text = monthlyPayment.ToString();
				}
				else
				{
					// Display an error message if input is not valid
					ResultTextBlock.Text = "Invalid input. Please enter numeric values.";
				}
			}
			catch (Exception ex)
			{
				// Handle any unexpected errors
				ResultTextBlock.Text = $"An error occurred: {ex.Message}";
			}
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
