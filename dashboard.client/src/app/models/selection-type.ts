export enum SelectionType {
  Elite = "Elite",
}

// Function to get all values of SelectionType enum
export const getAllSelectionTypes = (): SelectionType[] => {
  return Object.keys(SelectionType).filter(key => isNaN(Number(key))) as SelectionType[];
}
