using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

 
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "State is Required")]
        [Display(Name = "State")]
        public string State { get; set; }
        public IEnumerable<SelectListItem> States { get => new List<SelectListItem>
            {
                new SelectListItem
                {

                    Value = "AL",
                    Text = "Alabama"
                },
                new SelectListItem
                {

                    Value = "AK",
                    Text = "Alaska"
                },
                new SelectListItem
                {

                    Value = "AZ",
                    Text = "Arizona"
                },
                new SelectListItem
                {

                    Value = "AR",
                    Text = "Arkansas"
                },
                new SelectListItem
                {

                    Value = "CA",
                    Text = "California"
                },
                new SelectListItem
                {

                    Value = "CO",
                    Text = "Colorado"
                },
                new SelectListItem
                {

                    Value = "CT",
                    Text = "Connecticut"
                },
                new SelectListItem
                {

                    Value = "DC",
                    Text = "District of Columbia"
                },
                new SelectListItem
                {

                    Value = "DE",
                    Text = "Delaware"
                },
                new SelectListItem
                {

                    Value = "FL",
                    Text = "Florida"
                },
                new SelectListItem
                {

                    Value = "GA",
                    Text = "Georgia"
                },
                new SelectListItem
                {

                    Value = "HI",
                    Text = "Hawaii"
                },
                new SelectListItem
                {

                    Value = "IA",
                    Text = "Iowa"
                },
                new SelectListItem
                {

                    Value = "ID",
                    Text = "Idaho"
                },
                new SelectListItem
                {

                    Value = "IL",
                    Text = "Illinois"
                },
                new SelectListItem
                {

                    Value = "IN",
                    Text = "Indiana"
                },
                new SelectListItem
                {

                    Value = "KS",
                    Text = "Kansas"
                },
                new SelectListItem
                {

                    Value = "KY",
                    Text = "Kentucky"
                },
                new SelectListItem
                {

                    Value = "LA",
                    Text = "Louisiana"
                },
                new SelectListItem
                {

                    Value = "MD",
                    Text = "Maryland"
                },
                new SelectListItem
                {

                    Value = "ME",
                    Text = "Maine"
                },
                new SelectListItem
                {

                    Value = "MA",
                    Text = "Massachsetts"
                },
                new SelectListItem
                {

                    Value = "MI",
                    Text = "Michigan"
                },
                new SelectListItem
                {

                    Value = "MN",
                    Text = "Minnesota"
                },
                new SelectListItem
                {

                    Value = "MS",
                    Text = "Mississippi"
                },
                new SelectListItem
                {

                    Value = "MO",
                    Text = "Missouri"
                },
                new SelectListItem
                {

                    Value = "MT",
                    Text = "Montana"
                },
                new SelectListItem
                {

                    Value = "NE",
                    Text = "Nebraska"
                },
                new SelectListItem
                {

                    Value = "NV",
                    Text = "Nevada"
                },
                new SelectListItem
                {

                    Value = "NH",
                    Text = "New Hampshire"
                },
                new SelectListItem
                {

                    Value = "NJ",
                    Text = "New Jersey"
                },
                new SelectListItem
                {

                    Value = "NM",
                    Text = "New Mexico"
                },
                new SelectListItem
                {

                    Value = "NY",
                    Text = "New York"
                },
                new SelectListItem
                {

                    Value = "NC",
                    Text = "North Carolina"
                },
                new SelectListItem
                {

                    Value = "ND",
                    Text = "North Dakota"
                },
                new SelectListItem
                {

                    Value = "OH",
                    Text = "Ohio"
                },
                new SelectListItem
                {

                    Value = "OK",
                    Text = "Oklahoma"
                },
                new SelectListItem
                {

                    Value = "OR",
                    Text = "Oregon"
                },
                new SelectListItem
                {

                    Value = "PA",
                    Text = "Pennsylvania"
                },
                new SelectListItem
                {

                    Value = "RI",
                    Text = "Rhode Island"
                },
                new SelectListItem
                {

                    Value = "SC",
                    Text = "South Carolina"
                },
                new SelectListItem
                {

                    Value = "SD",
                    Text = "South Dakota"
                },
                new SelectListItem
                {

                    Value = "TN",
                    Text = "Tennessee"
                },
                new SelectListItem
                {

                    Value = "TX",
                    Text = "Texas"
                },
                new SelectListItem
                {

                    Value = "UT",
                    Text = "Utah"
                },
                new SelectListItem
                {

                    Value = "VT",
                    Text = "Vermont"
                },
                new SelectListItem
                {

                    Value = "VA",
                    Text = "Virginia"
                },
                new SelectListItem
                {

                    Value = "WA",
                    Text = "Washington"
                },
                new SelectListItem
                {

                    Value = "WV",
                    Text = "West Virginia"
                },
                new SelectListItem
                {

                    Value = "WI",
                    Text = "Wisconsin"
                },
                new SelectListItem
                {

                    Value = "WY",
                    Text = "Wyoming"
                },
                new SelectListItem
                {

                    Value = "AS",
                    Text = "American Samoa"
                },
                new SelectListItem
                {

                    Value = "FM",
                    Text = "Federated States of Micronesia"
                },
                new SelectListItem
                {

                    Value = "GU",
                    Text = "Guam"
                },
                new SelectListItem
                {

                    Value = "MH",
                    Text = "Marshall Islands"
                },
                new SelectListItem
                {

                    Value = "MP",
                    Text = "Northern Mariana Islands"
                },
                new SelectListItem
                {

                    Value = "PR",
                    Text = "Puerto Rico"
                },
                new SelectListItem
                {

                    Value = "VI",
                    Text = "US Virgin Islands"
                },
                new SelectListItem
                {

                    Value = "AB",
                    Text = "Alberta"
                },
                new SelectListItem
                {

                    Value = "BC",
                    Text = "British Columbia"
                },
                new SelectListItem
                {

                    Value = "MB",
                    Text = "Manitoba"
                },
                new SelectListItem
                {

                    Value = "NB",
                    Text = "New Brunswick"
                },
                new SelectListItem
                {

                    Value = "NF",
                    Text = "Newfoundland"
                },
                new SelectListItem
                {

                    Value = "NT",
                    Text = "Northwest Territories"
                },
                new SelectListItem
                {

                    Value = "NS",
                    Text = "Nova Scotia"
                },
                new SelectListItem
                {

                    Value = "NU",
                    Text = "Nunavut"
                },
                new SelectListItem
                {

                    Value = "ON",
                    Text = "Ontario"
                },
                new SelectListItem
                {

                    Value = "PE",
                    Text = "Prince Edward Island"
                },
                new SelectListItem
                {

                    Value = "QC",
                    Text = "Québec"
                },
                new SelectListItem
                {

                    Value = "SK",
                    Text = "Saskatchewan"
                },
                new SelectListItem
                {

                    Value = "YT",
                    Text = "Yukon"
                }
            };
        }

        [Required(ErrorMessage = "Zip Code is Required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string ZipCode { get; set; }

    }



}
