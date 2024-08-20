export enum CrossoverType {
  Uniform = "Uniform",
  OnePoint = "OnePoint",
  ThreeParent = "ThreeParent",
  TwoPoint = "TwoPoint",
  VotingRecombination = "VotingRecombination"
}

// Function to get all values of CrossoverType enum
export function getAllCrossoverTypes(): CrossoverType[] {
  return Object.keys(CrossoverType).filter(key => isNaN(Number(key))) as CrossoverType[];
}
