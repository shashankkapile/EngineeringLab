using LRUCache;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== LRU Cache Demo ===\n");

        var cache = new Cache<string, int?>(3);

        Console.WriteLine("1. Adding items to cache (capacity = 3)");
        cache.Put("a", 1);
        Console.WriteLine("   Put('a', 1)");
        cache.Put("b", 2);
        Console.WriteLine("   Put('b', 2)");
        cache.Put("c", 3);
        Console.WriteLine("   Put('c', 3)");
        Console.WriteLine("   Cache state: {a=1, b=2, c=3}");

        // Test 2: Get operation updates recency
        Console.WriteLine("\n2. Accessing 'a' makes it most recently used");
        var valueA = cache.Get("a");
        Console.WriteLine($"   Get('a') = {valueA}");
        Console.WriteLine("   Order now: b (LRU) -> c -> a (MRU)");

        // Test 3: Eviction on capacity overflow
        Console.WriteLine("\n3. Adding 'd' should evict 'b' (the LRU item)");
        cache.Put("d", 4);
        Console.WriteLine("   Put('d', 4)");

        var valueB = cache.Get("b");
        Console.WriteLine($"   Get('b') = {(valueB.HasValue ? valueB.ToString() : "null")} (null means evicted)");

        // Test 4: Verify other items still exist
        Console.WriteLine("\n4. Verifying other items still accessible");
        Console.WriteLine($"   Get('c') = {cache.Get("c")}");
        Console.WriteLine($"   Get('a') = {cache.Get("a")}");
        Console.WriteLine($"   Get('d') = {cache.Get("d")}");

        // Test 5: Update existing key
        Console.WriteLine("\n5. Updating existing key");
        cache.Put("c", 30);
        Console.WriteLine("   Put('c', 30) - updates value and marks as MRU");
        Console.WriteLine($"   Get('c') = {cache.Get("c")}");

        // Test 6: Add another item, should evict 'a' now
        Console.WriteLine("\n6. Adding 'e' should evict 'a' (now the LRU)");
        cache.Put("e", 5);
        Console.WriteLine("   Put('e', 5)");
        var evictedA = cache.Get("a");
        Console.WriteLine($"   Get('a') = {(evictedA.HasValue ? evictedA.ToString() : "null")} (null means evicted)");
        Console.WriteLine($"   Get('d') = {cache.Get("d")}");

        Console.WriteLine("\n=== Demo Complete ===");

        Console.Read();
    }
}