# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    # @param a list of ListNode
    # @return a ListNode
    def mergeKLists(self, lists):
        if (len(lists) == 1):
            return lists[0]
        elif (len(lists) < 1):
            return None
        results, i = [], 0
        while (i < len(lists)):
            if (i + 1 < len(lists)):
                results.append(self.merge(lists[i], lists[i + 1]))
            else:
                results.append(lists[i])
            i += 2
        return self.mergeKLists(results)

    def merge(self, left, right):
        head = ListNode(0)
        cur = head
        while (left != None and right != None):
            if (left.val < right.val):
                cur.next = left
                left = left.next
            else:
                cur.next = right
                right = right.next
            cur = cur.next

        if (left != None):
            cur.next = left
        if (right != None):
            cur.next = right
        return head.next