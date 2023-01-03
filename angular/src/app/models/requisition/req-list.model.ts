export interface Requisition {
    requisitionID: string,
    requisitionCode: string,
    potentialNumber: string,
    complexity: string,
    requisitionDate: Date,
    deadlineDate: Date,
    clientName: string,
    clientCountreyID: string,
    projectType: string,
    requisitionStatus: number,
    expectedStartDate: Date,
    budget: number,
    departmentID: string,
    currencyID: string,
    projectDescription: string,
    jobDescription : string
    duration : number,
    durationUnits : string,
    shiftTimings :string ,
    noOfResources : number ,
    openPositions : number,
    keyDescription : string,
    preferredEducation : string,
    minExperience : number,
    MaxExperience: number,
    jdFileName : string,
    skillID : string,
    mandatory : number,
    experience: number,
  comments: string,
  estimatedBudget: number,
    partnerId : string
}

export interface Country {
  countryID: string,
  countryName: string
}

export interface Department {
  departmentID: string,
  departmentName: string
}

export interface Currency {

  currencyID: string,
  currencyName: string
}
