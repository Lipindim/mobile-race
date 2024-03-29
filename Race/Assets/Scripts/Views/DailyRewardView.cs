﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardView : BaseShowableView
{
    private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
    private const string TimeGetRewardKey = nameof(TimeGetRewardKey);

    [Header("Settings Time Get Reward")]
    [SerializeField]
    private float _timeCooldown = 86400;

    [SerializeField]
    private float _timeDeadline = 172800;

    [Header("Settings Rewards")]
    [SerializeField]
    private List<Reward> _rewards;

    [SerializeField]
    private Slider _sliderNewReward;

    [SerializeField]
    private Transform _mountRootSlotsReward;

    [SerializeField]
    private ContainerSlotRewardView _containerSlotRewardView;

    [SerializeField]
    private Button _getRewardButton;

    [SerializeField]
    private Button _backButton;

    public float TimeCooldown => _timeCooldown;

    public float TimeDeadline => _timeDeadline;

    public List<Reward> Rewards => _rewards;

    public Slider SliderNewReward => _sliderNewReward;

    public Transform MountRootSlotsReward => _mountRootSlotsReward;

    public ContainerSlotRewardView ContainerSlotRewardView => _containerSlotRewardView;

    public Button GetRewardButton => _getRewardButton;

    public Button BackButton => _backButton;

    public int CurrentSlotInActive
    {
        get => PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0);
        set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
    }

    public DateTime? TimeGetReward
    {
        get
        {
            var data = PlayerPrefs.GetString(TimeGetRewardKey, null);

            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
            else
                PlayerPrefs.DeleteKey(TimeGetRewardKey);
        }
    }

    private void OnDestroy()
    {
        _getRewardButton.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();
    }
}
