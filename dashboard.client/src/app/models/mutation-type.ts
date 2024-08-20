export enum MutationType {
  FlipBit = "FlipBit",
  Displacement = "Displacement",
  Insertion = "Insertion",
  PartialShuffle = "PartialShuffle",
  ReverseSequence = "ReverseSequence",
  Twors = "Twors",
  Uniform = "Uniform"
}

// Arrow function to return all Types
export const getAllMutationTypes = (): MutationType[] => {
  return Object.keys(MutationType).filter(key => isNaN(Number(key))) as MutationType[];
}
