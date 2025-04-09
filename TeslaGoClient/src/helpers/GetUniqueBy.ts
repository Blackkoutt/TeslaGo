export const getUniqueBy = <T>(list: T[], getKey: (item: T) => string | number): T[] => {
  const map = new Map<string | number, T>();
  list.forEach((item) => {
    const key = getKey(item);
    if (!map.has(key)) {
      map.set(key, item);
    }
  });
  return Array.from(map.values());
};
